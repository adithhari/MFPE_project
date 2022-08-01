import axios from "axios";


const http = axios.create({
    headers: { 'content-type': 'application/json' },
    baseURL: 'http://localhost:61614/'
});

http.interceptors.request.use(config => {
    const token = window.localStorage.getItem('apitoken');
    config.headers['Authorization'] = 'Bearer ' + token;
    return config;
}, error => {
    Promise.reject(error);
});


const getProducts = () => {
    
    return http.get('/api/Product');
}
const getCategory = () => {
    return http.get('/api/Category');
}
const getProductsById = id =>{
    return http.get('/api/Product/'+id);
}
const getCategoryById = id =>{
    return http.get('/api/Category/'+id);
}       

const addNewProducts = Obj => {
    return http.post('/api/Product',Obj);
}

const updateProduct = (id,obj) => {
    console.log(id);
    console.log(obj);
    return http.put('api/Product/'+id,obj);
}
const deleteProduct = id => {
    return http.delete('api/Product/'+id);
}
let ProductService = { getProducts , addNewProducts , getProductsById , updateProduct , deleteProduct , getCategoryById , getCategory };
export default ProductService;