import { useEffect, useState } from 'react';
import { Link,useNavigate } from 'react-router-dom';
import StockService from "../../services/StockServices";

const OrderList = props => {

    const [quotation, setQuotation] = useState([]);
    useEffect(() => {
        StockService.getQuotation().then(res=>{
            setQuotation([...res.data]);

        }).catch(err=>{
            alert(err.response.statusText);
        });

    },[quotation.length]) 

    return(
        <div className='row'>
            <div className='col-12'>
                <h1>QuotationList</h1>
                <table className='table'>
                <thead>
                    <tr>
                        <th>CustomerName</th>
                        <th>CustomerPhonenumber</th>
                        <th>TotalAmount</th>
                        <th>Actions</th>
                        </tr>
                         
                </thead>
                <tbody>
                    {quotation.map(t => <tr key={t.id}>
                        <td>{t.customerName}</td>
                        <td>{t.phoneNumber}</td>
                        <td>{t.totalAmount}</td>
                        <td>
                            <Link to={'/home/BillDetails/'+t.id}><button className='btn btn-primary btn-sm'>Details</button></Link>
                            </td>
                        </tr>
                        )}
                         </tbody>
            </table>
                   <div className="form-group mt-4">
                    <Link to={'/home' }><button className="btn btn-light btn-lg">Back</button></Link>
                </div>
                </div>
            
    
            
                
            
            
        </div>
    )}

export default OrderList;