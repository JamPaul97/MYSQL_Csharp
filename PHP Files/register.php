<?php
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    require('db.php');
    
    //gather post info
    $username = $_POST['username'];
    $password = $_POST['password'];
    $email = $_POST['email'];
    $trn_date = $_POST['date'];
    $emailSubject = $_POST['emailSubject'];
    $emailMessage = $_POST['emailMessage']; //MustContains 'activation_key_placeholder' somewhere
    //check for duplicate username/email
    $user_check_query = "SELECT * FROM users WHERE username='$username' OR email='$email' LIMIT 1";
    $result = mysqli_query($con, $user_check_query);
    $user = mysqli_fetch_assoc($result);
  
    if ($user) {
        if ($user['username'] === $username) {
            $jsonResponse = array(
                "Username"=>$username, 
                "Date"=>$trn_date,
                "Email"=>$email,
                "Successful"=>false,
                "Message"=>"Username is already in use");
            echo json_encode($jsonResponse);
            exit();
        }

        if ($user['email'] === $email) {
            $jsonResponse = array(
                "Username"=>$username, 
                "Date"=>$trn_date,
                "Email"=>$email,
                "Successful"=>false,
                "Message"=>"Email is already in use");
            echo json_encode($jsonResponse);
            exit();
        }
    }
    $username = stripslashes($username);
    $username = mysqli_real_escape_string($con,$username); 
    $email = stripslashes($email);
    $email = mysqli_real_escape_string($con,$email);
    $password = stripslashes($password);
    $password = mysqli_real_escape_string($con,$password);
    $trn_date = date("Y-m-d H:i:s");
    $activation_key = generateRandomString(20);
    $query = "INSERT into `users` (username, password, email, trn_date,activation_key)    VALUES ('$username', '".md5($password)."', '$email', '$trn_date','$activation_key')";
    $result = mysqli_query($con,$query);
    if($result){
        $emailMessage = str_replace("activation_key_placeholder",$activation_key,$emailMessage);
        mail ( $email , $emailSubject , $emailMessage );
        $jsonResponse = array(
            "Username"=>$username, 
            "Date"=>$trn_date,
            "Email"=>$email,
            "Successful"=>true,
            "Message"=>"User registered successfully.Please check your email.");
        echo json_encode($jsonResponse);
        exit();
    }
    
}
function generateRandomString($length = 20) {
    $characters = '0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
    $charactersLength = strlen($characters);
    $randomString = '';
    for ($i = 0; $i < $length; $i++) {
        $randomString .= $characters[rand(0, $charactersLength - 1)];
    }
    return $randomString;
}
//public string Username;
//public string Date;
//public string Email;
//public bool Successful;
//public string Message;
?>