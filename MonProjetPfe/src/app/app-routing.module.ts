import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FilesviewComponent } from './filesview/filesview.component';
import { HomeComponent } from './Home/home/home.component';
import { HomeemployeComponent } from './homeemploye/homeemploye/homeemploye.component';
import { HomeresponsableComponent } from './homeresponsable/homeresponsable.component';
import { LoginComponent } from './login/login.component';
import { SendreqComponent } from './sendreq/sendreq/sendreq.component';
import { AdminGuard } from './Services/guard/admin.guard';
import { ResGuard } from './Services/guard/res.guard';
import { UploadfileComponent } from './uploadfile/uploadfile.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'home', component: HomeComponent, },
  { path: 'homeresponsable', component: HomeresponsableComponent },
  { path: 'upload', component: UploadfileComponent },
  { path: 'viewfile', component: FilesviewComponent },
  { path: 'homeemploye', component: HomeemployeComponent, canActivate: [ResGuard] },
  { path: 'sendreq', component: SendreqComponent },



];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

}
