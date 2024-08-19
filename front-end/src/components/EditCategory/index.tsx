import React, { useState, useEffect } from 'react';
import { Button, Form, Modal, Alert, Spinner } from 'react-bootstrap';
import { updateCategory } from '../../services/categoryService';
import { Category } from '../../types/types';
import { AxiosError } from 'axios';

interface EditCategoryProps {
  show: boolean;
  handleClose: () => void;
  onSuccess: (message: string) => void;
  categoryToEdit: Category;
}

const EditCategory: React.FC<EditCategoryProps> = ({ show, handleClose, onSuccess, categoryToEdit }) => {
  const [title, setTitle] = useState('');
  const [validated, setValidated] = useState(false);
  const [showAlert, setShowAlert] = useState(false);
  const [errorMessages, setErrorMessages] = useState<string[]>([]);
  const [isLoading, setIsLoading] = useState(false);

  useEffect(() => {
    if (categoryToEdit) {
      setTitle(categoryToEdit.title);
    }
  }, [categoryToEdit]);

  useEffect(() => {
    if (!show) {
      setTitle('');
      setValidated(false);
      setShowAlert(false);
      setErrorMessages([]);
    }
  }, [show]);

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    event.stopPropagation();

    setValidated(true);

    const form = event.currentTarget as HTMLFormElement;
    if (form.checkValidity() === false) {
      setShowAlert(true);
      return;
    }

    setShowAlert(false);
    setErrorMessages([]);
    setIsLoading(true);

    try {
      await updateCategory(categoryToEdit.id, title);
      onSuccess('Category updated successfully!');
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
        <Modal.Title>Edit Category</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        {showAlert && errorMessages.length > 0 && (
          <Alert variant="danger">
            <ul>
              {errorMessages.map((msg, index) => (
                <li key={index}>{msg}</li>
              ))}
            </ul>
          </Alert>
        )}
        <Form noValidate validated={validated} onSubmit={handleSubmit}>
          <Form.Group className="mb-3" controlId="categoryTitle">
            <Form.Label>Category Title</Form.Label>
            <Form.Control
              required
              type="text"
              placeholder="Enter category title"
              value={title}
              onChange={(e) => setTitle(e.target.value)}
            />
            <Form.Control.Feedback type="invalid">
              Please provide a category title.
            </Form.Control.Feedback>
          </Form.Group>
          <Modal.Footer>
            <Button variant="secondary" onClick={handleClose} disabled={isLoading}>
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

export default EditCategory;
