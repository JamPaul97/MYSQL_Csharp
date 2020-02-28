<?php
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    require('db.php');
    
    //gather post info
    $username = $_POST['username'];
    $password = $_POST['password'];
    $query = "SELECT * FROM `users` WHERE username='$username' and password='".md5($password)."'";
    $result = mysqli_query($con,$query) or die(mysql_error());
    $user = mysqli_fetch_array($result);
    $rows = mysqli_num_rows($result);
    if($rows==1){
        //login done
        $jsonResponse = array(
            "Username"=>$username, 
            "Coockie"=>user[5],
            "Successful"=>true,
            "Message"=>"Coockie grabed");
        echo json_encode($jsonResponse);
        exit();
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
    $jsonResponse = array("Username"=>$username, "Coockie"=>$user[5]);
    echo json_encode($jsonResponse);
}
//public string Username;
//public string Coockie;
//public bool Successful;
//public string Message;
?>