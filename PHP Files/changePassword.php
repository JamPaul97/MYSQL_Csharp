<?php
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    require('db.php');
    
    //gather post info
    $username = $_POST['username'];
    $password = $_POST['password'];
    $coockie = $_POST['coockie'];
    $newPassword = $_POST['newPassword'];
    $query = "SELECT * FROM `users` WHERE username='$username' and password='".md5($password)."' and coockie='$coockie'";
    $result = mysqli_query($con,$query) or die(mysql_error());
    $rows = mysqli_num_rows($result);
    if($rows==1){
        $query = "UPDATE users SET password=md5('$newPassword') WHERE username = '$username'";
        $result = mysqli_query($con,$query) or die(mysql_error());
        $jsonResponse = array(
            "Username"=>$username, 
            "Successful"=>true,
            "Message"=>"Password was changed");
        echo json_encode($jsonResponse);
        exit();
    }
    else
    {
        $jsonResponse = array(
            "Username"=>$username, 
            "Successful"=>false,
            "Message"=>"Username, Password or Coockie was incorrect. Check your login credentials or try to login again");
        echo json_encode($jsonResponse);
        exit();
    }    
}
//public string Username;
//public bool Successful;
//public string Message;
?>