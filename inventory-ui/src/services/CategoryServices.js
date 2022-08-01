import axios from "axios";


const http = axios.create({
    headers: { 'content-type': 'application/json', 'Authorization': '' },
    baseURL: 'http://localhost:61614/'
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

const addCategories =  obj => {
    return http.post('/api/Category',obj);
}

const getCategoriesById = id => {
    return http.get('/api/Category/'+id);
}

const updateCategories = (id,obj) => {
    return http.put('/api/Category/'+id,obj);
}

const deleteCategory = Id => {
    return http.delete('/api/Category/'+Id);
}



let CategoriesService = {getCategories, addCategories, getCategoriesById, updateCategories, deleteCategory};
export default CategoriesService;