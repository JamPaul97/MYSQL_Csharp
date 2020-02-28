<?php
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    require('db.php');
    
    //gather post info
    $email = $_POST['email'];
    $activationKey = $_POST['activationKey'];
    $query = "SELECT * FROM `users` WHERE email='$email'";
    $result = mysqli_query($con,$query) or die(mysql_error());
    $user = mysqli_fetch_array($result);
    if($user == null)
    {
        $jsonResponse = array(
            "Email"=>$email, 
            "Successful"=>false,
            "Message"=>"There is no account with that email.");
        echo json_encode($jsonResponse);
        exit();
    }
    else if($user[6] != null)
    {
        if($user[6] == $activationKey)
        {
            $query = "UPDATE users SET activation_key=null WHERE email = '$email'";
            $result = mysqli_query($con,$query) or die(mysql_error());
            $jsonResponse = array(
                "Email"=>$email, 
                "Successful"=>true,
                "Message"=>"Account activated successfully. You can log in now.");
            echo json_encode($jsonResponse);
            exit();
        }
        else
        {
            $jsonResponse = array(
                "Email"=>$email, 
                "Successful"=>false,
                "Message"=>"The provided key is wrong. Please check the key again.");
            echo json_encode($jsonResponse);
            exit();
        }
    }
    else
    {
        $jsonResponse = array(
            "Email"=>$email, 
            "Successful"=>false,
            "Message"=>"Account is already activated.Please log in.");
        echo json_encode($jsonResponse);
        exit();
    }
}
else{
    $jsonResponse = array(
        "Email"=>$email, 
        "Successful"=>false,
        "Message"=>"There was an internal error. Please try again.");
    echo json_encode($jsonResponse);
    exit();
}
?>