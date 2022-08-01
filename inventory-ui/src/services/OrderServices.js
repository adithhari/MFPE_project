import axios from "axios";


const http = axios.create({
    headers: { 'content-type': 'application/json', 'Authorization': '' },
    baseURL: 'http://localhost:61614/',
    
});

http.interceptors.request.use(config => {
    const token = window.localStorage.getItem('apitoken');
    config.headers['Authorization'] = 'Bearer ' + token;
    return config;
}, error => {
    Promise.reject(error);
});


const getCategories = () => {
    return http.get('/api/Category');
}
const getCategoriesById = id => {
    return http.get('/api/Category/'+id);
}

const getCustomers = () => {
    return http.get('api/Customers');
}
const getCustomerById = id =>{
    return http.get('api/Customers/'+id);
}

const getProducts = () => {
    
    return http.get('/api/Product');
}
const getProductsById = id =>{
    return http.get('/api/Product/'+id);
}




let OrderService = { getCategories, getCategoriesById, getCustomers, getCustomerById, getProducts, getProductsById}
export default OrderService;