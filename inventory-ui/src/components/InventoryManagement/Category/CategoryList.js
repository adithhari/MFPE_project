import CategoriesService from '../../../services/CategoryServices';
import { useEffect, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';

const CategoryList =  props => {
    const [categories, setCategories] = useState([]);
    useEffect(() => {
        CategoriesService.getCategories().then(res=>{
            setCategories([...res.data]);
        }).catch(err =>{
            alert(err.response.statusText);
        });
    }, [categories.length])

    const nav = useNavigate();
    const handleDelete = e =>{
        console.log(e);
        const result = window.confirm('Are you sure you want to delete ?');
        if (result) {
            CategoriesService.deleteCategory(e).then(res => {                
                alert('Employee removed successfully');
                const cat = [...categories];   
                const currentCat = cat.filter(s=>s.id!==e);
                setCategories([...currentCat]);
                nav('/home/Category');
            }).catch(res => {
                alert(res.response.status);
            });
        } 
       } 

    return <div className='row'>
        <div className='col-12'>
        <h2>Categories List</h2>
        <Link to='/home/add-category' className='nav-link'>Add New Category</Link>
        <table className='table table-hover'>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Description</th>
                    </tr>
                </thead>
                <tbody>
                    {categories.map(c => <tr key={c.id}>
                        <td>{c.id}</td>
                        <td>{c.categoryName}</td>
                        <td>{c.catgoryDescription}</td>
                        <td><Link to={'/home/Category/' + c.id}><button className='btn btn-primary btn-sm'>Edit</button></Link></td>
                        <td><button className='btn btn-danger btn-sm' onClick={()=>handleDelete(c.id)}>Delete</button></td>

                    </tr>)}
                </tbody>
            </table>
            
        </div>
    </div>
    }

export default CategoryList;
