import { Link } from 'react-router-dom';

const Home = props =>{
    var uname = () =>{
        props.getUserName();
    }
    const getUserName = () => {
        if (props.userName.length == 0) {
          return 'Guest';
        }
        return `${props.userName}`;
      }
    return <>
        {props.isLoggedIn === true &&
            <h1>Welcome {getUserName()}</h1>
        }

        </>
}
export default Home;