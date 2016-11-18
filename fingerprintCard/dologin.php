<?php
echo $_POST["Admin_name"];
echo $_POST["Admin_password"];
$admin_n=$_POST["Admin_name"];
$admin_psd=$_POST["Admin_password"];

$conn=new mysqli('localhost', 'root', '12580', 'fingerprint_card');
$result=$conn->query("select password from admin where admin_name='$admin_n'");
if($result->num_rows>0){
    while($row=$result->fetch_assoc()){
        echo "<br/>".$row['password']."<br/>";
        if($row['password']==$admin_psd){
            header("Location:http://localhost/fingerprintCard/load.php");
            
            break;
        }
    }
    echo "您所输入的密码错误，请重新输入";
}else echo "您的用户名错误";
