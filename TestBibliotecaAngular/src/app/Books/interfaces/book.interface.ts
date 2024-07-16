//interface que representa la estructura de un libro
export interface Book{
  id: number;
  title: string;
  author: string;
  stock: number;
  lendBooks: number;
  available: number;
}
