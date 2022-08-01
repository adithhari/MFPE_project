import { useState } from "react";
import { useNavigate,Link } from 'react-router-dom';
import CategoriesService from "../../../services/CategoryServices";


const AddCategory = props =>{

    const [categories, setCategories] = useState({ categoryName: '', catgoryDescription: '' })


   
    const handleSubmit = e => {
        e.preventDefault();
        CategoriesService.addCategories(categories).then(res => {
            if(res.status===201){
                alert('Categories details Added');
            }
        }).catch(res => { 
            alert(res.response.status);

        });
    }

    const handleChange = e => {
        let { name, value } = e.target;
        setCategories({...categories, [name]: value });
    } 
        
    
    return <form method="post" className="m-4" onSubmit={handleSubmit}>
    <div className="row">
        <div className="col-6">
            <h2>Categories</h2>
            <div className="form-group">
                <label>Enter Category Name</label>
                <input type="text"
                    className="form-control"
                    id="categoryName"
                    name="categoryName"
                    value={categories.categoryName}
                    onChange={handleChange} />
            </div>
            <div className="form-group">
                <label>Enter Category Description</label>
                <input type="text"
                    className="form-control"
                    id="catgoryDescription"
                    name="catgoryDescription"
                    value={categories.catgoryDescription}
                    onChange={handleChange} />
            </div>
            <div className="form-group m-2">
                <button type="submit" className="btn btn-primary btn-sm" >Submit</button>
            </div>
            <div className="form-group mt-4">
                <Link to={'/home/Category'}><button className="btn btn-light btn-sm">Back</button></Link>
            </div>
        </div>
    </div>
</form>

}
export default AddCategory;