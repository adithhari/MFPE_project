import { useEffect, useState } from "react";
import { useParams,useNavigate,Link } from "react-router-dom";
import EmployeeService from '../../services/EmployeeServices';

const RegisterEmployee = props =>{
    const [employee, setEmployee] = useState({
        fullname: '',
        userName: '',
        email: '',
        phoneNumber: '',
        password: '',
        confirmPassword: ''
    })
    const nav = useNavigate();
    const handleSubmit = ev => {
        ev.preventDefault();
        EmployeeService.addEmployee(employee).then(res => {
            if(res.status===201){
                alert('Employee details Added');
            }
        })
        .catch(err => {
            alert(err.response.status);
        });
    }

    const handleChange = e => {
        let { name, value} = e.target;
        setEmployee({ ...employee, [name]: value });
    }

    return <div className="row">
    <div className="col-md-5">
        <h1>Create New Employee</h1>
        <form method="post" onSubmit={handleSubmit}>
            <div className="form-group">
                <label htmlFor="fullname">Enter Full Name :</label>
                <input type="text"
                    id="fullname"
                    name="fullname"
                    className="form-control"
                    value={employee.fullname}
                    onChange={handleChange}
                    required />
            </div>
            <div className="form-group">
                <label htmlFor="userName">Enter UserName :</label>
                <input type="text"
                    id="userName"
                    name="userName"
                    className="form-control"
                    value={employee.userName}
                    onChange={handleChange}
                    required />
            </div>
            <div className="form-group">
                <label htmlFor="email">Enter Email :</label>
                <input type="text"
                    id="email"
                    name="email"
                    className="form-control"
                    value={employee.email}
                    onChange={handleChange}
                    required />
            </div>
            <div className="form-group">
                <label htmlFor="phoneNumber">Enter Phone Number :</label>
                <input type="text"
                    id="phoneNumber"
                    name="phoneNumber"
                    className="form-control"
                    value={employee.phoneNumber}
                    onChange={handleChange}
                    required />
            </div>
            <div className="form-group">
                <label htmlFor="password">Enter the password :</label>
                <input type="password"
                    id="password"
                    name="password"
                    className="form-control"
                    value={employee.password}
                    onChange={handleChange}
                    required />
            </div>
            <div className="form-group">
                <label htmlFor="confirmPassword">Confirm the password </label>
                <input type="password"
                    id="confirmPassword"
                    name="confirmPassword"
                    className="form-control"
                    value={employee.confirmPassword}
                    onChange={handleChange}
                />
            </div>

            <div className="form-group mt-4">
                <button type="submit" className="btn btn-primary">Save</button>
            </div>
            <div className="form-group mt-4">
                <Link to={'/home/employee'}><button className="btn btn-light btn-sm">Back</button></Link>
            </div>
        </form>
    </div>
</div>


}
export default RegisterEmployee;