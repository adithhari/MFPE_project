import CustomerService from '../../../services/CustomerServices';
import { useEffect, useState } from 'react';
import { Link,useNavigate } from 'react-router-dom';
 const CustomerList=props=>{
    const [customers, setCustomers] = useState([]);
    useEffect(() => {
        CustomerService.getCustomers().then(res => {
            console.log(res.data);
            setCustomers([...res.data]);
        }).catch(err => {
            alert(err.response.statusText);
        });
    }, [customers.length])
    const nav = useNavigate();
    const handleDelete = c =>{
        console.log(c);
        const result = window.confirm('Are you sure you want to delete ?');
        
        if (result) {
           CustomerService.deleteCustomer(c).then(res => {
                alert('Customer removed successfully');
                const cust=[...customers];
                const currentcust=cust.filter(s=>s.id!==c);
                setCustomers([...currentcust]);
                nav('/home/customers');
            }).catch(res => {
                alert(res.response.status);
            });
        } 
       }   
    return <div className='row'>
    <div className='col-12'>
        <h2>Customers List</h2>
        <Link to={'/home/add-customer' }>Add Customer</Link>
        <table className='table table-hover'>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>FullName</th>

                    <th>PhoneNumber</th>
                    <th>Address</th>
                    
                    
                </tr>
            </thead>
            <tbody>
                {customers.map(t => <tr key={t.id}>
                    <td>{t.id}</td>
                    <td>{t.fullname}</td>
                    
                    
                    <td>{t.phoneNumber}</td>
                    <td>{t.address}</td>
                    <td> 
                        <Link to={'/home/edit-customer/' + t.id}><button  className="btn btn-primary btn-sm">Edit</button></Link>                                               
                    </td>
                    <td>
                        <button className='btn btn-danger btn-sm' onClick={()=>handleDelete(t.id)}>Delete</button>
                    </td>
                   
                    
                </tr>)}
            </tbody>
        </table>
    </div>
</div>
}
export default CustomerList;