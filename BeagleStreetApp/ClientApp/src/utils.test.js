import { upperCaseFirst } from './utils';

describe('utils', function () {
	it('returns a the provided string with uppercase first character', function () {
		let str = 'test string';

		let upperString = upperCaseFirst(str);
		let expected = 'Test string';

		expect(upperString).toBe(expected);
	});
});