import ProductService from '../../../services/ProductServices';
import { useEffect, useState } from 'react';
import { Link,useNavigate } from 'react-router-dom';

 const ProductsList=props=>{
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
    const handleDelete = c =>{
        console.log(c);
        const result = window.confirm('Are you sure you want to delete ?');
        
        if (result) {
            ProductService.deleteProduct(c).then(res => {
                alert('Product removed successfully');
                const prod=[...products];
                const currentprod=prod.filter(s=>s.id!==c);
                setProducts([...currentprod]);
                nav('/products');
            }).catch(res => {
                alert(res.response.status);
            });
        } 
       }   

    return<div className='row'>
    <div className='col-12'>
        <h2>Products List</h2>
        <Link to={'/home/add-product' }>Add Products</Link>
        <table className='table table-hover'>
            <thead className="thead-light">
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
                    <td>
                        <Link to={'/home/edit-product/' + t.id}><button  className="btn btn-primary btn-sm">Edit</button></Link>
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

 export default ProductsList;