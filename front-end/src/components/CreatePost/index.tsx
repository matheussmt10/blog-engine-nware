import { useState, useEffect } from 'react';
import { Button, Form, Modal, Alert, Spinner } from 'react-bootstrap';
import { getCategories } from '../../services/categoryService';
import { createPost } from '../../services/postsService';
import { Category, PostRequest } from '../../types/types';
import { AxiosError } from 'axios';

interface CreatePostProps {
  show: boolean;
  handleClose: () => void;
  onSuccess: (message: string) => void;
}

const CreatePost: React.FC<CreatePostProps> = ({
  show,
  handleClose,
  onSuccess,
}) => {
  const [categories, setCategories] = useState<Category[]>([]);
  const [title, setTitle] = useState('');
  const [categoryId, setCategoryId] = useState<number | ''>('');
  const [publicationDate, setPublicationDate] = useState('');
  const [content, setContent] = useState('');
  const [validated, setValidated] = useState(false);
  const [showAlert, setShowAlert] = useState(false);
  const [errorMessages, setErrorMessages] = useState<string[]>([]);
  const [isLoading, setIsLoading] = useState(false);

  useEffect(() => {
    const loadCategories = async () => {
      try {
        const data = await getCategories();
        setCategories(data);
      } catch (error: unknown) {
        setErrorMessages([
          error instanceof Error ? error.message : 'Error fetching categories',
        ]);
        setShowAlert(true);
      }
    };

    loadCategories();
  }, []);

  const resetForm = () => {
    setTitle('');
    setCategoryId('');
    setPublicationDate('');
    setContent('');
    setValidated(false);
    setShowAlert(false);
    setErrorMessages([]);
  };

  useEffect(() => {
    if (!show) {
      resetForm();
    }
  }, [show]);

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    event.stopPropagation();

    const form = event.currentTarget as HTMLFormElement;
    if (form.checkValidity() === false) {
      setValidated(true);
      setShowAlert(true);
      return;
    }

    setValidated(true);
    setShowAlert(false);
    setErrorMessages([]);
    setIsLoading(true);

    const postData: PostRequest = {
      title,
      publicationDate,
      content,
      categoryId: Number(categoryId),
    };

    try {
      await createPost(postData);
      onSuccess('Post created successfully!');
      resetForm();
      handleClose();
    } catch (error) {
      if (error instanceof AxiosError) {
        const messages = error.response?.data?.errorMessages || [error.message];
        setErrorMessages(Array.isArray(messages) ? messages : [messages]);
      } else {
        setErrorMessages(['An unexpected error occurred.']);
      }
      setShowAlert(true);
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Add Post</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        {showAlert && errorMessages.length > 0 && (
          <Alert variant="danger" className="d-flex justify-content-center">
            <ul className="mt-3">
              {errorMessages.map((msg, index) => (
                <li key={index}>{msg}</li>
              ))}
            </ul>
          </Alert>
        )}
        <Form noValidate validated={validated} onSubmit={handleSubmit}>
          <Form.Group className="mb-3" controlId="postTitle">
            <Form.Label>Post</Form.Label>
            <Form.Control
              required
              type="text"
              placeholder="Type your title"
              value={title}
              onChange={(e) => setTitle(e.target.value)}
            />
            <Form.Control.Feedback type="invalid">
              Please provide a post title.
            </Form.Control.Feedback>
          </Form.Group>

          <Form.Group className="mb-3" controlId="postCategory">
            <Form.Label>Category</Form.Label>
            <Form.Select
              required
              value={categoryId}
              onChange={(e) => setCategoryId(Number(e.target.value))}
            >
              <option value="">Choose a category</option>
              {categories.map((cat) => (
                <option key={cat.id} value={cat.id}>
                  {cat.title}
                </option>
              ))}
            </Form.Select>
            <Form.Control.Feedback type="invalid">
              Please select a category.
            </Form.Control.Feedback>
          </Form.Group>

          <Form.Group className="mb-3" controlId="postDate">
            <Form.Label>Publication Date</Form.Label>
            <Form.Control
              required
              type="date"
              placeholder="Date"
              value={publicationDate}
              onChange={(e) => setPublicationDate(e.target.value)}
              pattern="\d{4}-\d{2}-\d{2}"
            />
            <Form.Control.Feedback type="invalid">
              Please provide a valid date in the format MM-DD-YYYY.
            </Form.Control.Feedback>
          </Form.Group>

          <Form.Group className="mb-3" controlId="postContent">
            <Form.Label>Content</Form.Label>
            <Form.Control
              required
              as="textarea"
              rows={5}
              placeholder="Type your content here..."
              value={content}
              onChange={(e) => setContent(e.target.value)}
            />
            <Form.Control.Feedback type="invalid">
              Please provide the content for the post.
            </Form.Control.Feedback>
          </Form.Group>

          <Modal.Footer>
            <Button
              variant="secondary"
              onClick={handleClose}
              disabled={isLoading}
            >
              Close
            </Button>
            <Button variant="primary" type="submit" disabled={isLoading}>
              {isLoading ? (
                <>
                  <Spinner
                    as="span"
                    animation="border"
                    size="sm"
                    role="status"
                    aria-hidden="true"
                  />{' '}
                  Loading...
                </>
              ) : (
                'Submit'
              )}
            </Button>
          </Modal.Footer>
        </Form>
      </Modal.Body>
    </Modal>
  );
};

export default CreatePost;
