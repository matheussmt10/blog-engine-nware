import { useState, useEffect, useCallback } from 'react';
import {
  Button,
  Card,
  Container,
  ListGroup,
  Alert,
  Spinner,
} from 'react-bootstrap';
import CreateCategory from '../../components/CreateCategory';
import CreatePost from '../../components/CreatePost';
import EditPost from '../../components/EditPost';
import EditCategory from '../../components/EditCategory';
import SuccessModal from '../../components/SuccessMessageModel/SuccessMessageModel';
import { getCategories } from '../../services/categoryService';
import { getPosts } from '../../services/postsService';
import { Category, PostResponse } from '../../types/types';

const Home: React.FC = () => {
  const [categories, setCategories] = useState<Category[]>([]);
  const [posts, setPosts] = useState<PostResponse[]>([]);
  const [showCreateCategory, setShowCreateCategory] = useState(false);
  const [showCreatePost, setShowCreatePost] = useState(false);
  const [showEditPost, setShowEditPost] = useState(false);
  const [showEditCategory, setShowEditCategory] = useState(false);
  const [showSuccess, setShowSuccess] = useState(false);
  const [successMessage, setSuccessMessage] = useState('');
  const [isLoadingCategories, setIsLoadingCategories] = useState(false);
  const [isLoadingPosts, setIsLoadingPosts] = useState(false);
  const [errorMessages, setErrorMessages] = useState<string[]>([]);
  const [showAlert, setShowAlert] = useState(false);
  const [postToEdit, setPostToEdit] = useState<PostResponse | undefined>(
    undefined
  );
  const [categoryToEdit, setCategoryToEdit] = useState<Category | undefined>(
    undefined
  );

  const loadCategories = useCallback(async () => {
    setIsLoadingCategories(true);
    try {
      const data = await getCategories();
      setCategories(data || []);
    } catch (error) {
      setErrorMessages([
        error instanceof Error ? error.message : 'Error loading categories',
      ]);
      setShowAlert(true);
      setCategories([]);
    } finally {
      setIsLoadingCategories(false);
    }
  }, []);

  const loadPosts = useCallback(async () => {
    setIsLoadingPosts(true);
    try {
      const data = await getPosts();
      setPosts(data?.posts || []);
    } catch (error) {
      setErrorMessages([
        error instanceof Error ? error.message : 'Error loading posts',
      ]);
      setShowAlert(true);
      setPosts([]);
    } finally {
      setIsLoadingPosts(false);
    }
  }, []);

  useEffect(() => {
    loadCategories();
    loadPosts();
  }, [loadCategories, loadPosts]);

  const handleShowSuccess = (message: string) => {
    setSuccessMessage(message);
    setShowSuccess(true);
  };

  const handleCloseSuccess = () => {
    setShowSuccess(false);
    loadCategories();
    loadPosts();
  };

  const handleCloseCreateCategory = () => setShowCreateCategory(false);
  const handleShowCreateCategory = () => setShowCreateCategory(true);

  const handleCloseCreatePost = () => setShowCreatePost(false);
  const handleShowCreatePost = () => setShowCreatePost(true);

  const handleCloseEditPost = () => {
    setShowEditPost(false);
    setPostToEdit(undefined);
  };

  const handleShowEditPost = (post: PostResponse) => {
    setPostToEdit(post);
    setShowEditPost(true);
  };

  const handleCloseEditCategory = () => {
    setShowEditCategory(false);
    setCategoryToEdit(undefined);
  };

  const handleShowEditCategory = (category: Category) => {
    setCategoryToEdit(category);
    setShowEditCategory(true);
  };

  return (
    <Container className="d-flex flex-column gap-5 mt-5">
      {showAlert && errorMessages.length > 0 && (
        <Container className="w-25 align-items-center">
          <Alert
            variant="danger"
            className="d-flex justify-content-center mt-3"
          >
            {errorMessages.map((msg, index) => (
              <div key={index}>{msg}</div>
            ))}
          </Alert>
        </Container>
      )}

      <Container id="category_category" className="d-flex flex-column gap-5">
        <Container className="d-flex gap-5">
          <h1>Categories</h1>
          <Button
            variant="primary"
            onClick={handleShowCreateCategory}
            className="align-content-center"
          >
            Add
          </Button>
        </Container>
        <Container>
          {isLoadingCategories ? (
            <Spinner animation="border" />
          ) : (
            <Card style={{ width: '18rem' }}>
              <ListGroup variant="flush">
                {categories.length > 0 ? (
                  categories.map((cat) => (
                    <ListGroup.Item
                      key={cat.id}
                      action
                      onClick={() => handleShowEditCategory(cat)}
                    >
                      {cat.title}
                    </ListGroup.Item>
                  ))
                ) : (
                  <ListGroup.Item>No categories available</ListGroup.Item>
                )}
              </ListGroup>
            </Card>
          )}
        </Container>
      </Container>

      <Container id="category_post" className="d-flex flex-column gap-5">
        <Container className="d-flex gap-5">
          <h1>Posts</h1>
          <Button
            variant="primary"
            onClick={handleShowCreatePost}
            className="align-content-center"
          >
            Add
          </Button>
        </Container>
        <Container>
          {isLoadingPosts ? (
            <Spinner animation="border" />
          ) : (
            <Card style={{ width: '18rem' }}>
              <ListGroup variant="flush">
                {posts.length > 0 ? (
                  posts.map((post) => (
                    <ListGroup.Item
                      key={post.id}
                      action
                      onClick={() => handleShowEditPost(post)}
                    >
                      {post.title}
                    </ListGroup.Item>
                  ))
                ) : (
                  <ListGroup.Item>No posts available</ListGroup.Item>
                )}
              </ListGroup>
            </Card>
          )}
        </Container>
      </Container>

      <CreateCategory
        show={showCreateCategory}
        handleClose={handleCloseCreateCategory}
        onSuccess={handleShowSuccess}
      />
      <CreatePost
        show={showCreatePost}
        handleClose={handleCloseCreatePost}
        onSuccess={handleShowSuccess}
      />
      <EditPost
        show={showEditPost && postToEdit !== undefined}
        handleClose={handleCloseEditPost}
        onSuccess={handleShowSuccess}
        postToEdit={postToEdit!}
      />
      <EditCategory
        show={showEditCategory && categoryToEdit !== undefined}
        handleClose={handleCloseEditCategory}
        onSuccess={handleShowSuccess}
        categoryToEdit={categoryToEdit!}
      />

      <SuccessModal
        show={showSuccess}
        message={successMessage}
        handleClose={handleCloseSuccess}
      />
    </Container>
  );
};

export default Home;
