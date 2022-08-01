import { useEffect, useState } from "react";
import { useParams,Link } from "react-router-dom";
import EmployeeService from '../../services/EmployeeServices';

const EditEmployee = props =>{
    let { employeeId } = useParams();
    const [employee, setEmployee] = useState({
        id: '',
        fullname: '',
        userName: '',
        email: '',
        phoneNumber: ''
    })

    const EmployeeById = eid => {
        EmployeeService.getEmployeeById(eid).then(r => {
            console.log(r);
            setEmployee({ ...r.data });
        }).catch(r => {
            console.log(r);
            console.log(r.response.status);
        });
    }

        useEffect(() => {
            EmployeeById(employeeId);
        }, [employeeId]);

        const handleUpdate = (ev) => {
            ev.preventDefault();
            EmployeeService.updateEmployee(employeeId, employee).then(r => {
                if (r.status == 200) {
                    alert('Employee details updated');
                }
            }).catch(r => {
                console.log(r.reponse.status);
            });
        }

        const handleChange = (ev) => {
            let { name, value} = ev.target;
            setEmployee({ ...employee, [name]: value });
        }


    return <div className="row">
    <div className="col-12">
        <h2>Update Employee</h2>
        <form method="post" onSubmit={handleUpdate}>
            <div className="row">
                <div className="col">
                    <input type="text"
                        className="form-control"
                        placeholder="Enter full name"
                        id="fullname"
                        name="fullname"
                        value={employee.fullname}
                        onChange={handleChange} />
                </div>
                <div className="col">
                    <input type="text"
                        className="form-control"
                        placeholder="Enter UserName"
                        id="userName"
                        name="userName"
                        value={employee.userName}
                        onChange={handleChange} />
                </div>
                <div className="col">
                    <input type="text"
                        className="form-control"
                        placeholder="Enter Email"
                        id="email"
                        name="email"
                        value={employee.email}
                        onChange={handleChange} />
                </div>
                <div className="col">
                    <input type="text"
                        className="form-control"
                        placeholder="Enter Phone Number"
                        id="phoneNumber"
                        name="phoneNumber"
                        value={employee.phoneNumber}
                        onChange={handleChange} />
                </div>
            </div>
            <div className='form-group mt-4'>
                    <button type="submit" className='btn btn-primary'>
                        Update
                    </button>
            </div>
            <div className="form-group mt-4">
                <Link to={'/home/employee'}><button className="btn btn-light btn-sm">Back</button></Link>
            </div>
        </form>
    </div>
    </div>
}

export default EditEmployee;