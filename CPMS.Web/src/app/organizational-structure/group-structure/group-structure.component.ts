import { Component, Input, OnInit } from '@angular/core';
import { GroupDto } from "../../_models/groupDto";

@Component({
    selector: 'group-structure',
    templateUrl: './group-structure.component.html',
    styleUrls: ['./group-structure.component.css']
})
export class GroupStructureComponent implements OnInit {

    @Input() group: GroupDto;
    @Input() level: number;

    constructor() {
    }

    ngOnInit() {
    }

}
