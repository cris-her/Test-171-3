import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WebpayPlusComponent } from './webpay-plus.component';

describe('WebpayPlusComponent', () => {
  let component: WebpayPlusComponent;
  let fixture: ComponentFixture<WebpayPlusComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WebpayPlusComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WebpayPlusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
