
   function show(input) {  
       if (input.files && input.files[0]) {  
           var filerdr = new FileReader();  
           filerdr.onload = function (e) {  
               $('#user_img').attr('src', e.target.result);  
           }  
           filerdr.readAsDataURL(input.files[0]);  
       }  
   }  
