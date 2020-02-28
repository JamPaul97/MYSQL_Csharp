<?php
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    require('db.php');
    
    //gather post info
    $email = $_POST['email'];
    $emailSubject = $_POST['emailSubject'];
    $emailMessage = $_POST['emailMessage']; //MustContains 'activation_key_placeholder' somewhere
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
    else if($user[6] == null)
    {
        $jsonResponse = array(
            "Email"=>$email, 
            "Successful"=>false,
            "Message"=>"This account is already activated.");
        echo json_encode($jsonResponse);
        exit();
    }
    else
    {
        $emailMessage = str_replace("activation_key_placeholder",$activation_key,$emailMessage);
        mail ( $email , $emailSubject , $emailMessage );
        $jsonResponse = array(
            "Email"=>$email, 
            "Successful"=>true,
            "Message"=>"Activation key sented.");
        echo json_encode($jsonResponse);
        exit();
    }
}
else
{
    $jsonResponse = array(
        "Email"=>$email, 
        "Successful"=>false,
        "Message"=>"There was an internal error. Please try again.");
    echo json_encode($jsonResponse);
    exit();
}
?>