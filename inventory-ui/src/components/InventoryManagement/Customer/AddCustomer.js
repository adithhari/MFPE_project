
import { Link,useNavigate } from 'react-router-dom';
import CustomerService from '../../../services/CustomerServices';
import { useState } from "react";
 const AddCustomer=props=>{
    const [customer, Setcustomer] = useState({
        fullname: '',
        phoneNumber: '',
        address: ''
        
    })
    const handleCustomerDetailsChange = ev => {
        let { name, value } = ev.target;
        Setcustomer({ ...customer, [name]: value });
    }
    const handleSubmit = ev => {
        ev.preventDefault();
        CustomerService.addNewCustomer(customer).then(res => {
            alert('Customer Details Added');
        }).catch(res => { });
    }
    return <div className="row">
        <div className="col-md-5">
            <h2>Create a New Customer</h2>

            <form method="post" onSubmit={handleSubmit}>
            <div className="form-group">
                <label htmlFor="fullname">Enter Full Name :</label>
                        <input type="text"
                            className="form-control"
                            id="fullname"
                            name="fullname"
                            value={customer.fullname}
                            onChange={handleCustomerDetailsChange}
                            required />
                    </div>
                    
                <div className="form-group">
                <label htmlFor="phone">Enter PhoneNumber :</label>
                        <input type="phone"
                            className="form-control"
                            id="phoneNumber"
                            name="phoneNumber"
                            value={customer.phoneNumber}
                            onChange={handleCustomerDetailsChange}
                            required />
                    </div>
                
                
                <div className="form-group">
                <label htmlFor="address">Enter Your Address :</label>
                        <input type="textarea"
                            className="form-control"
                            id="address"
                            name="address"
                            value={customer.address}
                            onChange={handleCustomerDetailsChange}
                            required/>
                        
                    </div>
            
                    <div className="form-group mt-4">
                <button type="submit" className="btn btn-primary">Save</button>
                </div>
                    <div className="form-group mt-4">
                    <Link to={'/home/customers' }><button className="btn btn-light btn-sm">Back</button></Link>
                </div>
                    
            </form>
            </div>
        </div>
                
          
}
export default AddCustomer;