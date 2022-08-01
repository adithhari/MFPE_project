import { useEffect, useState } from 'react';
import { Link,useNavigate } from 'react-router-dom';
import StockService from '../../services/StockServices';
import OrderService from '../../services/OrderServices';


const Order = props =>{

    const [customer, setCustomers] = useState([]);

    const [products, setProducts] = useState([]);
    const [product, setProduct] = useState({
        productId:'',
        productName:'',
        mrp:0,
        qty:0,
        amount:0,
    })

    const [order , setOrders] = useState({
        
        //customer :{customerId:'',customerName:'',phoneNumber:''},
        customerId: '',
        customerName: '',
        phoneNumber: '',
        totalAmount: 0,
        products: []
    })

// total = order.products.reduce(x=>products.price *product.qty,0);

    useEffect(() => {
        OrderService.getCustomers().then(res=>{
            setCustomers([...res.data]);
        }).catch(err =>{
            alert(err.response.statusText);
        });
    }, [customer.length])

    useEffect(() => {
        OrderService.getProducts().then(res=>{
            setProducts([...res.data]);
        }).catch(err =>{
            alert(err.response.statusText);
        });
    }, [products.length])

    const handleCustomerChange = ev =>{
        let { name, value} = ev.target;
        var cust = customer.find(obj => obj.id === parseFloat(value));
        console.log(cust);
        setOrders({ ...order, customerId: cust.id,customerName: cust.fullname, phoneNumber: cust.phoneNumber} );
    }

    const handleProductChange = ev =>{
        let { name, value} = ev.target;
        var prod = products.find(obj => obj.id === parseFloat(value));
        console.log(prod);
        setProduct({...product, productId: prod.id, productName: prod.name, mrp: prod.price, qty: prod.qty});
    }

    const handleQtyChange= ev=>{
        var qty = parseFloat(ev.target.value);
        var amount = product.mrp * qty;
        setProduct({...product, qty: qty ,amount: amount });
    }

    const addProduct =ev =>{        
        ev.preventDefault();
        // const p = { productId: product.id, productName: product.name, mrp: product.price, qty: product.qty, amount: product.amount };
        console.log(product);
        const customerOrder = [...order.products];
        customerOrder.push(product);
        console.log(customerOrder);
        // setOrders({ ...order, products: customerOrder });
        var totalAmount = customerOrder.map(p=> p.amount).reduce((accumulator, current) => accumulator + current, 0);       
        console.log(totalAmount); 
        setOrders({...order, products: customerOrder, totalAmount: totalAmount});
        setProduct({productId:'',productName:'', mrp:0, qty:0, amount:0, });
    }

    const handleSubmit = ev => {
        ev.preventDefault();

        console.log(order.totalAmount);
        console.log(order);

        StockService.addOrder(order).then(res => {
            alert('Order added');
        }).catch(res =>{ console.log(res);});
    }



return <div className="row">
<div className="col-12">
    <h2>Place Order</h2>
    <form method="post" onSubmit={handleSubmit} >
        <div className="row">
            <div className='col'>
                <label htmlFor="fullname">Customer Name</label>
                    <select className="form-select" onChange={handleCustomerChange}  name="fullname">
                    { customer.map(c =>
                        <option key={c.id} value={c.id}>{c.fullname}</option>                            
                    )}
                    </select>
            </div>
            <div className="col">
                <label htmlFor="phoneNumber">Customer Phone Number</label>
                <input type="text"
                            className="form-control"
                            placeholder="Phone Number"
                            id="phoneNumber"
                            name="phoneNumber"
                            value={order.phoneNumber} 
                            readOnly={true}/>
            </div>
      </div>  
      <div className='row'>
            <div className='col'>
                <label htmlFor="name">Product Name</label>
                    <select className="form-select" onChange={handleProductChange} name="name">
                    { products.map(c =>
                        <option key={c.id} value={c.id}>{c.name}</option>
                    )}
                    </select>
            </div>

            <div className='col'>
                <label htmlFor="price">MRP</label>
                <input type="text"
                            className="form-control"
                            placeholder="MRP"
                            id="price"
                            name="price"    
                            value={product.mrp}
                            readOnly={true} />
        
            </div>
            <div className='col'>
                <label htmlFor="qty">Quantity</label>
                <input type="text"
                            className="form-control"
                            placeholder="qty"
                            id="qty"
                            name="qty"
                            value={product.qty} 
                            onChange={handleQtyChange}/>
            </div>

            <div className='col'>
                <label htmlFor="amount">Amount</label>
                <input type="text"
                            className="form-control"
                            placeholder="amount"
                            id="amount"
                            name="amount"
                            value={product.amount} 
                            readOnly={true}/>
            </div>
            <div className="row-sm-5">
                    <button type="button"
                        className="btn  btn-primary"
                        onClick={addProduct}>Add Product</button>
                </div>
      </div>


      <div className="row">
                <div className="col-12">
                    <table className="table">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Product Name</th>
                                <th>Price</th>
                                <th>Quantity</th>
                                <th>Amount</th>
                            </tr>
                        </thead>
                        <tbody>
                            {order.products?.map(p => <tr key={p.productId}>
                                <td>{p.productId}</td>
                                <td>{p.productName}</td>
                                <td>{p.mrp}</td>
                                <td>{p.qty}</td>
                                <td>{p.amount}</td>
                            </tr>)}
                        </tbody>
                    </table>
                </div>
                <div className='col-sm-2'>
                <label htmlFor="totalAmount">Total</label>
                <input type="text"
                            className="form-control"
                            placeholder="totalAmount"
                            id="totalAmount"
                            name="totalAmount"
                            value={order.totalAmount} 
                            onChange={addProduct}
                            readOnly={true}/>
            </div>

            </div>
            <div className="row">
                <div className="col">
                    <button type="submit"
                        className="btn btn-lg btn-primary">
                        Place Order
                    </button>
                </div>
            </div>
    </form>

</div>
</div>

}

export default Order;