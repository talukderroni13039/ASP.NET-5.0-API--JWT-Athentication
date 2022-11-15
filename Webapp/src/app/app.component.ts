import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent 
{
  title = 'wepapp';
  
  constructor(private http: HttpClient) 
  {

  }
  public token:string='';
  public generateToken() 
  {
   
   return this.http.post<any>('http://localhost:55552/api/Login/VerifyUser',{},{'params':{},'headers':{}})
   .subscribe
    (result=>
      {

        console.log(result);
        this.token=result;

      }
    );

    
  } 
  public validToken() 
  {
   const headers = new HttpHeaders().set('Content-Type', 'application/json')
   .set('Authorization', 'Bearer '+this.token)//must be jsonstring after bearer
   //.set('Authorization', 'Bearer '+this.token); 
    console.log(headers);
   return this.http.get<any>('http://localhost:55552/api/Login/GetName', { 'headers': headers })
     .subscribe
     (
        result=>
        {
         console.log('Authorized Method');
         alert('Authorized Method')
        }

     );
  } 
  public validTokenForAnotherAPI() 
  {
    
    const headers = new HttpHeaders().set('Content-Type', 'application/json').set('Authorization', 'Bearer '+this.token); //must be jsonstring after bearer

    return this.http.post<any>('http://localhost:55561/api/Test/GetNameFromAnotherAPI',{}, { 'headers': headers })
      .subscribe
      (
         result=>
         {
          console.log('Another Authorized Method');
          alert('Another Authorized Method')
         }
 
      );

  } 





}




