@{
    ViewData["Title"] = "Home Page";
    List<Product> products = (List<Product>)ViewData["products"];
    List<CartDetail> cartDetails = (List<CartDetail>)ViewData["cart"];
}


@section Scripts
{
    <script src="~/js/cart/index.js"></script>
}



< span style = "float:left; font-size:48px;" >
 

 </ span >
 < span style = "float:right" id = "totalPrice" >
    </ span >


@{
    if (cartDetails == null)
    {
        < div align = "center" >
 
             < span style = "font-size:24px" >
                  There is nothing in your cart!
                  Browse our products<a href= "/" > here </ a > now! :)
            </ span >
        </ div >
    }

    else
    {
        < span style = "margin-left:25px; font-size:22px; font-style:italic; font-weight:400" > Your Cart </ span >
     
             < br />< br />
     

             < table class= "table" align = "center";>
        
                    < thead class= "thead-light" >
         
                         < tr >
         
                             < th style = "text-align:left; font-size:16px; font-weight:900; padding-left:100px;" > Product </ th >
          
                              < th scope = "col" > </ th >
           
                               < th style = "text-align:center;font-size:16px; font-weight:900;" > Quantity </ th >
            
                                < th scope = "col" > </ th >
             
                                 < th style = "text-align:center;font-size:16px; font-weight:900;" > Price </ th >
              
                                  < th scope = "col" > </ th >
               
                                   < th scope = "col" > </ th >
                

                                </ tr >
                
                            </ thead >
                

                            < tbody style = "text-align:center;" >
                                 @foreach(var cd in cartDetails)

                {

                    < tr >
                        < td >
                            < div >

                                < div class= "card bg-light m-3" style = "float: left; border: 1px solid black; text-align: center; padding: 10px 10px; width: 220px; height: 300px; border-radius:5px;" >
  
                                      < div class= "card-header" >
   

                                           < img src = "@cd.Product.Image" width = "100" /> < br />
      

                                          </ div >
      
                                          < div class= "card-body" >
       

                                               < h5 class= "card-title" > @cd.Product.Name </ h5 >
        
                                                < div class= "card-text" >
         
                                                     < div style = "height:60px; text-align:left; font-size:12pt;" >
                                                          @cd.Product.Description
                                                      </ div >
          
                                                      < br />
          
                                                      < br />
          
                                                      < br />
          

                                                  </ div >
          

                                              </ div >
          
                                          </ div >
          



                                      </ div >
          
                                  </ td >
          
                                  < td >
          
                                      < div style = "padding-top:150px;" ></ div >
           
                                       < button style = "font-size:18px; width:35px; height:35px; text-align:center; padding-bottom:20px" class= "updatecartquantity btn btn-primary" product_id = "@cd.ProductId" plus = "false" > -</ button >
                 
                                         </ td >
                 
                                         < td >
                 
                                             < div style = "padding-top:150px;" ></ div >
                  
                                              < div style = "font-weight:900; font-size:20px;" id = "number_@cd.ProductId" >
                                                     @cd.Quantity
                                                 </ div >
                     
                                             </ td >
                     
                                             < td >
                     
                                                 < !--border - radius:20 %; -->
                          
                                                      < div style = "padding-top:150px;" ></ div >
                           
                                                       < button style = "font-size:18px; width:35px; height:35px; text-align:center; padding-bottom:10px" class= "updatecartquantity btn btn-primary" product_id = "@cd.ProductId" plus = "true" > +</ button >
                                 
                                                         </ td >
                                 
                                                         < td >
                                 
                                                             < div style = "padding-top:150px;" ></ div >
                                  
                                                              < span style = "font-size: 22px; font-weight: 900; " >
                                   
                                                                   < span id = "Total_@cd.ProductId" >
                                    @{
    double price = cd.Product.Price * cd.Quantity;
    string displayPrice = $"${price:#,0.00}";
}
@displayPrice
</ span >

</ span >



</ td >

< td >

< div style = "padding-top:150px;" ></ div >

< form id = "form" action = "/Cart/Remove" method = "POST" style = "font-size:24px; font-size:large;" >

    < input type = "hidden" name = "productId" value = "@cd.ProductId" />

         < input type = "Submit" value = "Remove" class= "btn btn-danger" />

          </ form >

      </ td >

      < td >

          < div >

          </ div >

      </ td >

  </ tr >



                }
            </ tbody >
        </ table >

        < hr />
        < br />


        < div align = "right" style = "font-size: 26px; font-weight:bold; margin-right:25px;" >
               Total: < span id = "cTotal" >
                @{
    double sum = 0.00;
    foreach (CartDetail cd in cartDetails)
    {
        sum = sum + cd.Product.Price * cd.Quantity;
    }
    string total = $"${sum:#,0.00}";
}
@total
</ span >

< br />< br />

</ div >


< div >

< span style = "float: left; margin-left:50px;" >

 < a href = "/Home/Index" class= "btn btn-primary" role = "button" >< strong > Continue Shopping </ strong ></ a >

      </ span >

      < span style = "float: right; margin-right:40px;" >

           < a href = "/Checkout/Index" onclick = "return checkLogin();" class= "btn btn-success" role = "button" >< strong > Checkout </ strong > </ a >
 
             </ span >
 
         </ div >
 

         < br />
 
         < br />
 
         < br />
 
         < br />
    }
}



