import { Component, OnInit } from '@angular/core';
import { OrganizationalStructureService } from "../_services/organizationalStructure.service";
import { OrganizationalStructureDto } from "../_models/organizationalStructureDto";

@Component({
    selector: 'app-organizational-structure',
    templateUrl: './organizational-structure.component.html',
    styleUrls: ['./organizational-structure.component.css']
})
export class OrganizationalStructureComponent implements OnInit {

    organizationalStructure: OrganizationalStructureDto;

    constructor(private organizationalStructureService: OrganizationalStructureService) {
    }

    ngOnInit() {

        this.organizationalStructureService.getOrganizationalStructure().subscribe(organizationalStructure => {
            this.organizationalStructure = organizationalStructure;
        });

    }

}
