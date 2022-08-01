import { useState } from "react";
import { useNavigate } from 'react-router-dom';

const Login = props =>{

    const [credentials, setCredentials] = useState({ userName: '', password: '' })
    const handleChange = e => {
        let { name, value } = e.target;
        setCredentials({...credentials, [name]: value });
    }
   
    const handleSubmit = e => {
        e.preventDefault();
        props.handleLogin({ ...credentials });
    }
    return <form method="post" className="m-4" onSubmit={handleSubmit}>
    <div className="row">
        <div className="col-6">
            <h2>Login</h2>
            <div className="form-group">
                <label>Enter username</label>
                <input type="text"
                    className="form-control"
                    id="userName"
                    name="userName"
                    value={credentials.userName}
                    onChange={handleChange} />
            </div>
            <div className="form-group">
                <label>Enter password</label>
                <input type="password"
                    className="form-control"
                    id="password"
                    name="password"
                    value={credentials.password}
                    onChange={handleChange} />
            </div>
            <div className="form-group m-2">
                <button type="submit" className="btn btn-primary btn-lg" >Login</button>
            </div>
        </div>
    </div>
</form>



}
export default Login;