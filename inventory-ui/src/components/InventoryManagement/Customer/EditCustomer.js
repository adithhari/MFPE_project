import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import CustomerService from '../../../services/CustomerServices';
import { Link } from 'react-router-dom';

const EditCustomer = props =>{
    let { customerId } = useParams();
    const [customer, setCustomers] = useState({
        id: '',
        fullname: '',
        phoneNumber: '',
        address:''
    })

    const CustomerById = cid => {
        CustomerService.getCustomerById(cid).then(r => {
            console.log(r);
            setCustomers({ ...r.data });
        }).catch(r => {
            console.log(r);
            console.log(r.response.status);
        });
    }

        useEffect(() => {
           CustomerById(customerId);
        }, [customerId]);

        const handleUpdate = (ev) => {
            ev.preventDefault();
            CustomerService.updateCustomer(customerId, customer).then(r => {
                if (r.status == 200) {
                    alert('Customer details updated');
                }
            }).catch(r => {
                console.log(r.reponse.status);
            });
        }

            const handleChange = (ev) => {
                let { name, value} = ev.target;
               setCustomers({ ...customer, [name]: value });
            }


    return <div className="row">
    <div className="col-12">
        <h2>Update Customer</h2>
        <form method="post" onSubmit={handleUpdate}>
            <div className="row">
                <div className="col">
                    <input type="text"
                        className="form-control"
                        placeholder="Enter FullName"
                        id="fullname"
                        name="fullname"
                        value={customer.fullname}
                        onChange={handleChange} />
                </div>
                <div className="col">
                    <input type="phone"
                        className="form-control"
                        placeholder="Enter PhoneNumber"
                        id="phoneNumber"
                        name="phoneNumber"
                        value={customer.phoneNumber}
                        onChange={handleChange} />
                </div>
                <div className="col">
                    <input type="textarea"
                        className="form-control"
                        placeholder="Enter Your Address"
                        id="address"
                        name="address"
                        value={customer.address}
                        onChange={handleChange} />
                </div>
               
            </div>
            <div className='form-group mt-2'>
                    <button type="submit" className='btn btn-primary'>
                        Update
                    </button>
                </div>
                <div className="form-group mt-4">
                    <Link to={'/home/customers' }><button className="btn btn-light btn-sm">Back</button></Link>
                </div>
        </form>
    </div>
    </div>
}

export default EditCustomer;