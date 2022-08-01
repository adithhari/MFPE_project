import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import StockService from "../../services/StockServices";
import React,{useRef} from 'react';

import {useReactToPrint} from 'react-to-print';
import 'bootstrap/dist/css/bootstrap.min.css';


const BillDetails=(props) =>{

    let {Id} = useParams();
    const [quotation,setQuotation] = useState({});
        useEffect(()=>{
            StockService.getQuotationById(Id).then(res=>{
                console.log(res);
                
                setQuotation({...res.data});
                
            }).catch(err=>{
                alert(err.response.statusText);

            });

        },[quotation.length]);
        const componentRef = useRef();
        const handlePrint = useReactToPrint({
        content:() => componentRef.current,
        documentTitle: 'Order Details',
        onAfterPrint:()=>alert('print success')
        });

    return(
        <div ref={componentRef} style={{width:'100%',height:window.innerHeight}}>
        <h1 className="text-center my-6 border py-2">Order Details</h1><div className="row">
        <div className="col-12">
            
            <dl>
                <dt>Customer ID</dt>
                <dd>{quotation.id}</dd>
                <dt>Customer Name</dt>
                <dd>{quotation.customerName}</dd>
                <dt>Customer Phonenumber</dt>
                <dd>{quotation.phoneNumber}</dd>
                <dt>Total Amount</dt>
                <dd>{quotation.totalAmount}</dd>
                
            </dl>
            <table className="table">
                <thead>
                    <tr>
                    <th>Product ID</th>
                    <th>Product Name</th>
                    <th>MRP</th>
                    <th>QTY</th>
                    <th>Amount</th>
                    </tr>
                </thead>
                <tbody>
                {quotation.products?.map(t => <tr key={t.id}>
                    
                    <td>{t.id}</td>
                   <td>{t.productName}</td>
                   <td>{t.mrp}</td>
                   <td>{t.qty}</td>
                   <td>{t.amount}</td>
                   </tr>)}

                

                
             
                </tbody>
            </table>
            <button onClick={handlePrint} className='btn btn-light btn-sm'>Print Bill</button>
            
            
        </div>

    </div>
    </div>

)}

export default BillDetails;