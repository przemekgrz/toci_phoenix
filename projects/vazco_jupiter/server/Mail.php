<?php
	require ('PHPMailer/PHPMailerAutoload.php');

	$mail=new PHPMailer();
$mail->isSMTP();

$mail->SMTPDebug = 1; // debugging: 1 = errors and messages, 2 = messages only
$mail->SMTPAuth = true; // authentication enabled
$mail->SMTPSecure = 'ssl'; // secure transfer enabled REQUIRED for GMail
$mail->Host = "smtp.gmail.com";
$mail->Port = 465; // or 587
$mail->IsHTML(true);
$mail->Username = 'tociszkolenia@gmail.com';
$mail->Password = 'T0CIszkolenia';
$mail->SetFrom("example@gmail.com");
$mail->Subject = "Test";
$mail->Body = "hello";
$mail->AddAddress('tociszkolenia@gmail.com');
 if(!$mail->Send())
	     {
		         echo "Mailer Error: " . $mail->ErrorInfo;
			     }
     else
	         {
			     echo "Message has been sent";
			         }
