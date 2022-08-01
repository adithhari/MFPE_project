import { useEffect, useState } from "react";
import EmployeeService from '../../services/EmployeeServices';
import { Link,useNavigate } from 'react-router-dom';

const EmployeeList = props =>{
    const [employees, setEmployees] = useState([]);
    useEffect(() => {
        EmployeeService.getEmployee().then(res => {
            console.log(res.data);
            setEmployees([...res.data]);
        }).catch(err => {
            alert(err.response.statusText);
        });
    }, [employees.length])

    const nav = useNavigate();
    const handleDelete = e =>{
        console.log(e);
        const result = window.confirm('Are you sure you want to delete ?');
        if (result) {
            EmployeeService.deleteEmployee(e).then(res => {                
                alert('Employee removed successfully');
                const emp = [...employees];   
                const currentEmp = emp.filter(s=>s.id!==e);
                setEmployees([...currentEmp]);
                nav('/home/employee');
            }).catch(res => {
                alert(res.response.status);
            });
        } 
       }   

    return <div className='row'>
    <div className='col-12'>
        <h2>Employees List</h2>
        <Link to={'/home/add-employee'}>Add Employee</Link>
        <center>
        <table className='table table-hover'>
            <thead>
                <tr>
                    <th scope="col">Name</th>
                    <th scope="col">USERNAME</th>
                    <th scope="col">Phone</th>
                    <th scope="col">EMAIL</th>
                </tr>
            </thead>
            <tbody>
                { employees.map(e => <tr key={e.id}>
                    <td>{e.fullname}</td>
                    <td>{e.userName}</td>
                    <td>{e.phoneNumber}</td>
                    <td>{e.email}</td>
                    <td><Link to={'/home/Employee/' + e.id}><button className='btn btn-primary btn-sm'>Edit</button></Link></td>
                    <td><button className='btn btn-danger btn-sm' onClick={()=>handleDelete(e.id)}>Delete</button></td>

                </tr>)}
            </tbody>
        </table>
        </center>
    </div>
</div>


}
export default EmployeeList;