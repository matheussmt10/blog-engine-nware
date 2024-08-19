import axios from 'axios';
import { Category } from '../types/types';

const API_URL = import.meta.env.VITE_API_URL;

export const getCategories = async (): Promise<Category[]> => {
  const response = await axios.get(`${API_URL}/categories`);
  return response.data.categories;
};

export const getCategoryById = async (id: number) => {
  const response = await axios.get(`${API_URL}/categories/${id}`);
  return response.data;
};

export const createCategory = async (title: string) => {
  await axios.post(`${API_URL}/categories`, {title}, {
        headers: {
          'Content-Type': 'application/json',
        },
      });
}

export const updateCategory = async (id: number, title: string) => {
  await axios.put(`${API_URL}/categories/${id}`, {title}, {
    headers: {
      'Content-Type': 'application/json',
    },
  });
}