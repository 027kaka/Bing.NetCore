// ============== UUID ============================
// Copyright 2019 简玄冰
// Licensed under the MIT license
// ================================================
// 参考地址：https://github.com/wulfsolter/angular2-uuid/blob/master/src/uuid.ts

/**
 * UUID
 */
export class UUID {
    public static UUID(): string {
        // tslint:disable-next-line:max-line-length
        if (typeof (window) !== 'undefined' && typeof (window.crypto) !== 'undefined' && typeof (window.crypto.getRandomValues) !== 'undefined') {
            // If we have a cryptographically secure PRNG, use that
            // http://stackoverflow.com/questions/6906916/collisions-when-generating-uuids-in-javascript
            const buf: Uint16Array = new Uint16Array(8);
            window.crypto.getRandomValues(buf);
            // tslint:disable-next-line:max-line-length
            return (this.pad4(buf[0]) + this.pad4(buf[1]) + '-' + this.pad4(buf[2]) + '-' + this.pad4(buf[3]) + '-' + this.pad4(buf[4]) + '-' + this.pad4(buf[5]) + this.pad4(buf[6]) + this.pad4(buf[7]));
        } else {
            // Otherwise, just use Math.random
            // https://stackoverflow.com/questions/105034/create-guid-uuid-in-javascript
            // https://stackoverflow.com/questions/11605068/why-does-jshint-argue-against-bitwise-operators-how-should-i-express-this-code
            return this.random4() + this.random4() + '-' + this.random4() + '-' + this.random4() + '-' +
                this.random4() + '-' + this.random4() + this.random4() + this.random4();
        }
    }

    private static pad4(num: number): string {
        let ret: string = num.toString(16);
        while (ret.length < 4) {
            ret = '0' + ret;
        }
        return ret;
    }

    private static random4(): string {
        return Math.floor((1 + Math.random()) * 0x10000)
            .toString(16)
            .substring(1);
    }
}