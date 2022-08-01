import { useEffect, useState } from "react";
import { useParams,Link } from "react-router-dom";
import CategoriesService from "../../../services/CategoryServices";

const EditCategory = props =>{
    let { categoryId } = useParams();
    const [category, setCategory] = useState({
        id: '',
        categoryName: '',
        catgoryDescription: '',
    })

    const CategoriesById = cid => {
        CategoriesService.getCategoriesById(cid).then(r =>{
            console.log(r);
            setCategory({ ...r.data });
        }).catch(r => {
            console.log(r);
            console.log(r.response.status);
        });
    }

        useEffect(() => {
            CategoriesById(categoryId);
        }, [categoryId]);

        const handleUpdate = (ev) => {
            ev.preventDefault();
            CategoriesService.updateCategories(categoryId, category).then(r => {
                if (r.status == 200) {
                    alert('Category details updated');
                }
            }).catch(r => {
                console.log(r.reponse.status);
            });
        }

        const handleChange = (ev) => {
            let { name, value} = ev.target;
            setCategory({ ...category, [name]: value });
        }   


    return <div className="row">
    <div className="col-12">
        <h2>Update Category</h2>
        <form method="post" onSubmit={handleUpdate}>
            <div className="row">
                <div className="col">
                    <input type="text"
                        className="form-control"
                        placeholder="Enter Category Name"
                        id="categoryName"
                        name="categoryName"
                        value={category.categoryName}
                        onChange={handleChange} />
                </div>
                <div className="col">
                    <input type="text"
                        className="form-control"
                        placeholder="Enter Category Description"
                        id="categoryDescription"
                        name="catgoryDescription"
                        value={category.categoryDescription}
                        onChange={handleChange} />
                </div>
            </div>
            <div className='form-group mt-2'>
                    <button type="submit" className='btn btn-primary btn-sm'>
                        Update Categories
                    </button>
                    <div className="form-group mt-4">
                        <Link to={'/home/Category'}><button className="btn btn-light btn-sm">Back</button></Link>
                    </div>
                </div>
        </form>
    </div>
    </div>
}

export default EditCategory;