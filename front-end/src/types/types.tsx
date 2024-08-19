export interface Category {
    id: number;
    title: string;
  }
  
export interface PostRequest {
    title: string;
    categoryId: number;
    publicationDate: string;
    content: string;
  }

  export interface PostResponse {
    id: number;
    title: string;
    categoryId: number;
    publicationDate: string;
    content: string;
  }

  export interface PostToEdit {
    id: number;
    title: string;
    categoryId: number;
    categoryTitle: string;
    publicationDate: string;
    content: string;
  }
