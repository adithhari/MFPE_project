import axios from "axios";


const http = axios.create({
    headers: { 'content-type': 'application/json', 'Authorization': '' },
    baseURL: 'https://localhost:44301'
});

http.interceptors.request.use(config => {
    const token = window.localStorage.getItem('apitoken');
    config.headers['Authorization'] = 'Bearer ' + token;
    return config;
}, error => {
    Promise.reject(error);
});

const addOrder = Obj => {
    return http.post('/api/Order',Obj);
}

const getQuotation = () => {
    return http.get('api/Order');
}
const getQuotationById = id =>{
    
    return http.get('api/Order/'+id);
}

let StockService = { addOrder, getQuotation, getQuotationById}
export default StockService;