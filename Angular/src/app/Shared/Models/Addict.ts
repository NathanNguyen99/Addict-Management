//import * as internal from "stream";
import { AddictDrugs } from "../Models/AddictDrugs";
import { AddictManagePlace } from "../Models/AddictManagePlace";
import { AddictClassify } from "./AddictClassify";

export interface Addict {
    oid	: string;
    addictCode	: string;
    firstName	: string;
    lastName	: string;
    fullName	: string;
    otherName	: string;
    genderID	: number;
    placeOfBirthID	: string;
    dateOfBirth : Date;
    // yearOfBirth	:number;
    // monthOfBirth	:number;
    // dayOfBirth	: number;
    pemanentAddress	: string;
    currentAddress	: string;
    profession	: string;
    phoneNumber	: string;
    socialNetworkAccount	: string;
    educationLevelID	: string;
    citizenID	: string;
    criminalConviction	: string;
    criminalRecord	: string;
    detoxed	: boolean;
    fartherName	: string;
    motherName	: string;
    partnerName	: string;
    characteristics	: string;
    remarks1	: string;
    remarks2	: string;
    manageType : number;
    complete	:boolean;
    completeDate	: Date;
    createDate	:Date;
    createUser	: string;
    imgLink	: string;
    updCount : number;
    managePlaceID	: string;
    correctRatio: number;
    drugs : AddictDrugs[];
    classifys : AddictClassify[];
    places : AddictManagePlace[];
}

// export interface AddictBase {
//     oid	: string;
//     addictCode	: string;
//     fullName	: string;
// }