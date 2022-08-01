import { Link } from 'react-router-dom';

const NavBar = props =>{
    const onLogout = () =>{
        props.handleLogout();
    }

    return <nav className="navbar navbar-expand-md bg-dark navbar-dark" >
    <div className="container-fluid">
        <a className="navbar-brand" href="#">Inventory Management</a>
        <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse" id="navbarSupportedContent">
            <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                {props.isLoggedIn === false &&
                    <li className="nav-item">
                        <Link to='/' className='nav-link'>Login</Link>
                    </li>
                }
                {props.isLoggedIn === true &&
                    <li className="nav-item">
                        <Link to='/home' className='nav-link'>Home</Link>
                    </li>
                }
                {props.role === 'Admin' &&
                    <li className="nav-item">
                            <Link to='/home/employee' className='nav-link'>Employee</Link>
                        </li>
                }
                {props.isLoggedIn === true &&
                    <li className="nav-item">
                            <Link to='/home/customers' className='nav-link'>Customers</Link>
                        </li>
                }
                {props.isLoggedIn === true &&
                    <li className="nav-item">
                            <Link to='/home/Category' className='nav-link'>Categories</Link>
                        </li>
                }
                {props.isLoggedIn === true &&
                    <li className="nav-item">
                            <Link to='/home/Product' className='nav-link'>Products</Link>
                        </li>
                }
                {props.isLoggedIn === true &&
                    <li className="nav-item">
                            <Link to='/home/stockreport' className='nav-link'>StockReport</Link>
                        </li>
                }

                {props.isLoggedIn === true &&
                    <li className="nav-item">
                            <Link to='/home/order' className='nav-link'>Place Order</Link>
                        </li>
                }

                {props.isLoggedIn === true &&
                    <li className="nav-item">
                            <Link to='/home/orderlist' className='nav-link'>Order List</Link>
                    </li>
                }


                {props.isLoggedIn === true &&
                    <span className="nav-item">
                        <a href='#' className='nav-link' onClick={onLogout}>Logout</a>
                </span>
                }
            </ul>
        </div>
    </div>
</nav>


}
export default NavBar;