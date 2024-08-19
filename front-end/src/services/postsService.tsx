import axios from 'axios';
import { PostRequest } from '../types/types';


const API_URL = import.meta.env.VITE_API_URL;


export const getPosts = async () => {
  const response = await axios.get(`${API_URL}/posts`);
  return response.data;
};


export const getPostById = async (id: number) => {
  const response = await axios.get(`${API_URL}/posts/${id}`);
  return response.data;
};


export const createPost = async (postData: PostRequest) => {
  const response = await axios.post(`${API_URL}/posts`, postData);
  return response.data;
};


export const updatePost = async (id: number, postData: PostRequest) => {
  const response = await axios.put(`${API_URL}/posts/${id}`, postData);
  return response.data;
};


export const deletePost = async (id: number) => {
  const response = await axios.delete(`${API_URL}/posts/${id}`);
  return response.data;
};
