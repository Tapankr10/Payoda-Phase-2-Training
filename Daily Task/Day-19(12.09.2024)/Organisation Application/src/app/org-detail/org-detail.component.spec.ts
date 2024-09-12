import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrgDetailComponent } from './org-detail.component';

describe('OrgDetailComponent', () => {
  let component: OrgDetailComponent;
  let fixture: ComponentFixture<OrgDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OrgDetailComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrgDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
