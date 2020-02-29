<?php
if ($_SERVER["REQUEST_METHOD"] == "POST") {
	require('db.php');
	$data = json_decode(file_get_contents('php://input'), true);
	$username = $data["Username"];
	$coockie = $data["Coockie"];
    $actualData = json_encode($data["Data"]);
    $query = "SELECT * FROM `users` WHERE username='$username'";
    $result = mysqli_query($con	,$query) or die(mysql_error());
    $rows = mysqli_num_rows($result);
    $user = mysqli_fetch_assoc($result);
	if($user != null)
	{
		if($user["coockie"] == $coockie)
		{
			$updateQuery = "UPDATE users SET data='$actualData' WHERE username ='$username' and coockie='$coockie'";
			$result = mysqli_query($con,$updateQuery) or die(mysql_error());
			$jsonResponse = array(
                "Username"=>$username, 
                "Data"=>$actualData,
                "Successful"=>true,
                "Message"=>"Data updated.");
            echo json_encode($jsonResponse);
            exit();
		}
		else
		{
            $jsonResponse = array(
                "Username"=>$username, 
                "Data"=>$actualData,
                "Successful"=>false,
                "Message"=>"Coockie was wrong.");
            echo json_encode($jsonResponse);
            exit();
		}
	}
	else 
	{
		$jsonResponse = array(
                "Username"=>$username, 
                "Data"=>$actualData,
                "Successful"=>false,
                "Message"=>"Usern not found.");
            echo json_encode($jsonResponse);
            exit();
	}
}
else
{
	$jsonResponse = array(
                "Username"=>null, 
                "Data"=>null,
                "Successful"=>false,
                "Message"=>"Internal server error.");
            echo json_encode($jsonResponse);
            exit();
}
?>