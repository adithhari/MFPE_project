import logo from './logo.svg';
import './App.css';

import { Routes, Route, useNavigate } from 'react-router-dom';
import { useState } from 'react';

import NavBar from './components/NavBar';
import SideBar from './components/SideBar';
import Home from './components/Home';

import Login from './components/Login';
import LoginService from './services/LoginServices';

import EmployeeList from './components/UserManagement/EmployeeList';
import RegisterEmployee from './components/UserManagement/RegisterEmployee';
import EditEmployee from './components/UserManagement/EditEmployee';

import CustomerList from './components/InventoryManagement/Customer/CustomerList';
import AddCustomer from './components/InventoryManagement/Customer/AddCustomer';
import EditCustomer from './components/InventoryManagement/Customer/EditCustomer';

import CategoryList from './components/InventoryManagement/Category/CategoryList';
import AddCategory from './components/InventoryManagement/Category/AddCategory';
import EditCategory from './components/InventoryManagement/Category/EditCategory';

import ProductsList from './components/InventoryManagement/Inventory/ProductsList';
import AddProducts from './components/InventoryManagement/Inventory/AddProducts';
import EditProducts from './components/InventoryManagement/Inventory/EditProducts';
import StockReport from './components/InventoryManagement/Inventory/StockReport';

import Order from './components/OrderManagement/Order';
import OrderList from './components/OrderManagement/OrderList';
import BillDetails from './components/OrderManagement/BillDetails';

function App() {
  const [userDetails, setUserDetails] = useState({
    fullName: '',
    userName: '',
    role: '',
    isLoggedIn: false
  });

  const getUserName = () => {
    if (userDetails.fullName.length == 0) {
      return 'Guest';
    }
    return `${userDetails.fullName}`;
  }

  const nav = useNavigate();
  const handleLogin = credentials => {
    LoginService.doLogin(credentials).then(obj => {
      setUserDetails({ ...obj.data, isLoggedIn: true });
      window.localStorage.setItem('apitoken', obj.data.token);
      nav('/home');
    }).catch(obj => {
      alert(obj.response.statusText);
    });
  }

  const handleLogout = () => {
    const obj = {
      fullName: '',
      userName: '',
      role: '',
      isLoggedIn: false
    };
    setUserDetails(obj);
    window.localStorage.removeItem('apitoken');
    nav('/');
  }


  return (<>
      <NavBar role={userDetails.role}
      isLoggedIn={userDetails.isLoggedIn}
      handleLogout={handleLogout} />

      <div className='container'>
        <div className='row'>
          <div className='col-12'>
            <Routes>
              
               {/* For_UserManagement */}
              <Route path='/' element={<Login handleLogin={handleLogin}/>}/>
              <Route path='/home' element={<Home isLoggedIn={userDetails.isLoggedIn}  userName = {userDetails.fullName} />}/>
                  {/* -->Employee */}
              <Route path='/home/add-employee' element={<RegisterEmployee/>}/>
              <Route path='/home/employee/:employeeId' element={<EditEmployee/>}/>
              <Route path='/home/employee' element={<EmployeeList/>}/>

              {/* For_InventoryManagement */}
                  {/* -->Customers */}
                  <Route path='/home/customers' element={<CustomerList />} />
                  <Route path='/home/add-customer' element={<AddCustomer />} />
                  <Route path='/home/edit-customer/:customerId' element={<EditCustomer />} />
                  {/* -->For_Categories */}
                  <Route path ='/home/Category' element={<CategoryList/>}/>
                  <Route path='/home/add-category' element={<AddCategory/>} />
                  <Route path='/home/category/:categoryId' element={<EditCategory/>}/>
                  {/* -->For_Categories */}
                  <Route path ='/home/product' element={<ProductsList/>}/>
                  <Route path='/home/add-product' element={<AddProducts/>} />
                  <Route path='/home/edit-product/:productId' element={<EditProducts/>}/>
                  <Route path='/home/stockreport' element={<StockReport/>}/>

              {/* For_StockManagement */}
              <Route path='/home/order' element={<Order/>}/>
              <Route path='/home/orderlist' element={<OrderList/>}/>
              <Route path='/home/billdetails/:Id' element={<BillDetails/>}/>


              </Routes>
          </div>
        </div>
      </div>
      </>
  );
}

export default App;
