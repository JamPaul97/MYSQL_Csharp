<?php
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    require('db.php');
    
    //gather post info
    $username = $_POST['username'];
    $password = $_POST['password'];
    $coockie = generateRandomString(10);
    $query = "SELECT * FROM `users` WHERE username='$username' and password='".md5($password)."'";
    $result = mysqli_query($con,$query) or die(mysql_error());
    $rows = mysqli_num_rows($result);
	$user = mysqli_fetch_assoc($result);
    if($rows==1){
		//Check if account is activated
		if(user[6] != null)
		{
			$jsonResponse = array(
			    "Username"=>$username, 
			    "Coockie"=>"",
			    "Successful"=>false,
			    "Message"=>"Account is not activated");
			echo json_encode($jsonResponse);
			exit();
		}else
		{
			//login done
			$query = "UPDATE users SET coockie='$coockie' WHERE username ='$username'";
			$result = mysqli_query($con,$query) or die(mysql_error());
			$jsonResponse = array(
			    "Username"=>$username, 
			    "Coockie"=>$coockie,
			    "Successful"=>true,
			    "Message"=>"User logged-in successfully");
			echo json_encode($jsonResponse);
			exit();
		}
    }
    else
    {
        $jsonResponse = array(
            "Username"=>$username, 
            "Coockie"=>"",
            "Successful"=>false,
            "Message"=>"Password was wrong or user doesn't exist");
        echo json_encode($jsonResponse);
        exit();
    }
    
}
function generateRandomString($length = 10) {
    $characters = '0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
    $charactersLength = strlen($characters);
    $randomString = '';
    for ($i = 0; $i < $length; $i++) {
        $randomString .= $characters[rand(0, $charactersLength - 1)];
    }
    return $randomString;
}
//public string Username;
//public string Coockie;
//public bool Successful;
//public string Message;
?>