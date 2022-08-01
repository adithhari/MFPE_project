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

const addNewCustomer = customerObj => {
    return http.post('api/Customers', customerObj);
}

const getCustomers = () => {
    return http.get('api/Customers');
}

const getCustomerById = id =>{
    return http.get('api/Customers/'+id);
}

const updateCustomer = (id,obj) => {
    return http.put('/api/Customers/'+id,obj);
}

const deleteCustomer = id => {
    return http.delete('/api/Customers/'+id);
}

let CustomerService = { getCustomers, getCustomerById, addNewCustomer , updateCustomer, deleteCustomer};
export default CustomerService;