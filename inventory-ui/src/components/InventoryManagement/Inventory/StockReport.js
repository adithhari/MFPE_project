import ProductService from '../../../services/ProductServices';
import { useEffect, useRef, useState } from 'react';
import { Link,useNavigate } from 'react-router-dom';

const StockReport = props =>{
    
    const [products, setProducts] = useState([]);

    useEffect(() => {
        ProductService.getProducts().then(res => {
            console.log(res.data);
            setProducts([...res.data]);
        }).catch(err => {
            alert(err.response.statusText);
        });
        
    }, [products.length])
    const nav = useNavigate();

    return <div className='row'>
    <div className='col-12' >
        <h2>Stock Report</h2>
        
        
        <table className='table'>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>CategoryName</th>
                    <th>ProductName</th>
                    
                    <th>Description</th>
                    <th>Price</th>
                    <th>AvailableQuantity</th>
                    
                    
                    
                </tr>
            </thead>
            <tbody>
                {products.map(t => <tr key={t.id}>
                    <td>{t.id}</td>
                    <td>{t.categoryName}</td>
                    <td>{t.name}</td>
                    <td>{t.description}</td>
                    <td>{t.price}</td>
                    <td>{t.availableQuantity}</td>
                    
                   
                    
                </tr>)}
            </tbody>
        </table>
    </div>

</div>
}

export default StockReport;