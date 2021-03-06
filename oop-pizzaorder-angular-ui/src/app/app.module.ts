import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
// tslint:disable-next-line:max-line-length
import {
  MatButtonModule, MatCheckboxModule, MatOptionModule, MatInputModule, MatSelectModule, MatSelectTrigger, MatRadioModule,
  MatRadioGroup
} from '@angular/material';
import { MatDialogModule } from '@angular/material/dialog';
import {MatBadgeModule} from '@angular/material/badge';
import { CustomComponent } from './custom/custom.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NavbarComponent } from './navbar/navbar.component';
import { SharedService } from './shared/shared.service';
import { MenuComponent } from './menu/menu.component';
import { OrderComponent } from './order/order.component';
import { CartComponent } from './cart/cart.component';

@NgModule({
  declarations: [
    AppComponent,
    CustomComponent,
    NavbarComponent,
    MenuComponent,
    OrderComponent,
    CartComponent,
  ],
    entryComponents: [
    ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatButtonModule,
    MatCheckboxModule,
    MatOptionModule,
    MatSelectModule,
    ReactiveFormsModule,
    FormsModule,
    MatRadioModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatButtonModule,
    MatBadgeModule
  ],
  exports: [
    MatButtonModule,
    MatCheckboxModule,
    MatOptionModule,
    MatSelectModule,
    MatSelectTrigger,
    MatRadioModule,
    MatRadioGroup,
    MatDialogModule,
    MatButtonModule,
    MatBadgeModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
