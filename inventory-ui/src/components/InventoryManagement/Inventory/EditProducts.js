import ProductService from '../../../services/ProductServices';
import { useEffect, useState } from 'react';
import { Link, useParams } from 'react-router-dom';
 const EditProducts=props=>{
        let { productId } = useParams();
        const [product, setProducts] = useState({
            id:'',
            name: '',
            description: '',
            price: 0,
            availableQuantity: 1,
            categoryId: 1,
        })
    
        const ProductById = pid => {
            ProductService.getProductsById(pid).then(r => {
                console.log(r);
                setProducts({ ...r.data });
            }).catch(r => {
                console.log(r);
                console.log(r.response.status);
            });
        }
    
        useEffect(() => {
            ProductById(productId);
         }, [productId]);
    
         const handleUpdate = (ev) => {
            ev.preventDefault();
            ProductService.updateProduct(productId, product).then(r => {
                if (r.status === 200) {
                    alert('Product updated');
                }
            }).catch(r => {
                console.log(r.reponse.status);
            });
        }
    
        const handleChange = (ev) => {
            let { name, value, type} = ev.target;
            if(name === 'categoryId' || type === 'number')
            {
                value = parseFloat(value);
            }
            setProducts({ ...product, [name]: value });
        }

    return<div className="row">
    <div className="col-12">
        <h2>Edit Product</h2>
        <form method="post" onSubmit={handleUpdate}>
            <div className="row">
                <div className="col">
                <label htmlFor="name">Product Name :</label>
                    <input type="text"
                        className="form-control"
                        placeholder="Product Name"
                        id="name"
                        name="name"
                        value={product.name}
                        onChange={handleChange} />
                </div>
                <div className="col">
                <label htmlFor="name">Description :</label>
                    <input type="text"
                        className="form-control"
                        placeholder="Description"
                        id="description"
                        name="description"
                        value={product.description}
                        onChange={handleChange} />
                </div>
                <div className="col">
                <label htmlFor="name">Price :</label>
                    <input type="number"
                        className="form-control"
                        placeholder="Price"
                        id="price"
                        name="price"
                        value={product.price}
                        onChange={handleChange} />
                </div>
                <div className="col">
                <label htmlFor="name">Available Quantity :</label>
                    <input type="number"
                        className="form-control"
                        placeholder="Available QTY"
                        id="availableQuantity"
                        name="availableQuantity"
                        value={product.availableQuantity}
                        onChange={handleChange} />
                </div>


            </div>
            <div className='form-group mt-4'>
                    <button type="submit" className='btn btn-primary'>
                        Update
                    </button>
            </div>
            <div className="form-group mt-4">
                <Link to={'/home/product'}><button className="btn btn-light btn-sm">Back</button></Link>
            </div>
        </form>
    </div>
    </div>

}

 export default EditProducts;