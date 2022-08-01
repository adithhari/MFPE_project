import axios from 'axios';
const http = axios.create({
    headers: { 'content-type': 'application/json' },
    baseURL: 'http://localhost:62743'
});

const doLogin = loginCredentails => {
    return http.post('/api/User/signin', loginCredentails);
}

let LoginService = {doLogin};
export default LoginService;