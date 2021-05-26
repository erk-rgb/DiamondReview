export default interface diamond {
    rowNr: BigInteger;
    id: number;
    fileName: string;
    type: string;
    typeId: number;
    itemType: string;
    itemTypeId: number;
    metalPropertyId: number;
    metalValue: string;
    shapePropertyId: number;
    shapeValue: string;
    position: number | null;
    thumbId: number | null;
    thumb: string;
}