import axios from "axios";


const http = axios.create({
    headers: { 'content-type': 'application/json'},
    baseURL: 'http://localhost:62743'
});

http.interceptors.request.use(config => {
    const token = window.localStorage.getItem('apitoken');
    config.headers['Authorization'] = 'Bearer ' + token;
    return config;
}, error => {
    Promise.reject(error);
});

const getEmployee = () => {
    return http.get('api/Employee');
}

const getEmployeeById = id => {
    return http.get('api/Employee/'+id);
}

const updateEmployee = (id,obj) => {
    console.log(id);
    console.log(obj);
    return http.put('/api/Employee/'+id,obj);
}

const deleteEmployee = employeeId => {
    return http.delete('/api/Employee/'+employeeId);
}

const addEmployee = obj =>{
    
    return http.post('/api/User/signup',obj);
}

let EmployeeService = { getEmployee, updateEmployee, deleteEmployee, getEmployeeById, addEmployee };
export default EmployeeService;