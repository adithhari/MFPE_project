import ProductService from '../../../services/ProductServices';
import { useEffect, useState } from 'react';
import { Link,useNavigate } from 'react-router-dom';

 const AddProducts=props=>{
    const [product, setProduct] = useState({
        name: '',
        description: '',
        price: '',
        availableQuantity: '',
        categoryId: 0
    })

    const [category, setCategory] = useState([])


    useEffect(() => {
        ProductService.getCategory().then(res => {
            console.log(res.data);
            setCategory([...res.data]);
        }).catch(err => {
            alert(err.response.statusText);
        });
    }, [category.length])

    const handleChange = ev => {
        console.log(ev);
        console.log("Handle change executed");
        let { name, value, type } = ev.target;
        console.log(value);
        if(name === 'categoryId' || type === 'number')
        {
            value = parseFloat(value);
        }
        setProduct({ ...product, [name]: value });
    }

    const handleUpdate = ev => {
        
        console.log(ev);
        ev.preventDefault();
        ProductService.addNewProducts(product).then(res => {
            alert('Product Added');
        }).catch(res => { 
            console.log(res);
        });
    } 

    return<div className="row">
    <div className="col-12">
        <h2>Add Products</h2>
        <form method="post" onSubmit={handleUpdate}>

            <div className="row">
                <div className="col">
                    <label htmlFor="name">Enter Name :</label>
                    <input type="text"
                        className="form-control"
                        placeholder="Enter FullName"
                        id="name"
                        name="name"
                        value={product.name}
                        onChange={handleChange} />
                </div>
                <div className="col">
                <label htmlFor="description">Enter description :</label>
                    <input type="text"
                        className="form-control"
                        placeholder="Enter Description"
                        id="description"
                        name="description"
                        value={product.description}
                        onChange={handleChange} />
                </div>
                <div className="col">
                <label htmlFor="price">Enter Price :</label>
                    <input type="number"
                        className="form-control"
                        placeholder="Enter the Price"
                        id="price"
                        name="price"
                        value={product.price}
                        onChange={handleChange} />
                </div>   

                <div className="col">
                <label htmlFor="availableQuantity">Enter Quantity :</label>
                    <input type="number"
                        className="form-control"
                        placeholder="Quantity"
                        id="availableQuantity"
                        name="availableQuantity"
                        value={product.availableQuantity}
                        onChange={handleChange} />
                </div>    
                <div className="col">
                <label htmlFor="categoryId">Choose Category :</label>
                    <select className="form-select" value={product.categoryId} onChange={handleChange} name="categoryId">
                    { category.map(c =>
                        <option key={c.id} value={c.id}>{c.categoryName}</option>
                    )}
                    </select>
                </div>
            </div>    

            <div className='form-group mt-4'>
                <button type="submit" className='btn btn-primary btn-sm'>Update</button>
            </div>
            <div className="form-group mt-4">
                <Link to={'/home/product' }><button className="btn btn-light btn-sm">Back</button></Link>
            </div>
        </form>
    </div>
    </div>
}

 export default AddProducts;