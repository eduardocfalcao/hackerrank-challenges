Array.prototype.equals = function (array) {
    // if the other array is a falsy value, return
    if (!array)
        return false;

    // compare lengths - can save a lot of time 
    if (this.length != array.length)
        return false;

    for (var i = 0, l=this.length; i < l; i++) {
        // Check if we have nested arrays
        if (this[i] instanceof Array && array[i] instanceof Array) {
            // recurse into the nested arrays
            if (!this[i].equals(array[i]))
                return false;       
        }           
        else if (this[i] != array[i]) { 
            // Warning - two different object instances will never be equal: {x:20} != {x:20}
            return false;   
        }           
    }       
    return true;
}
// Hide method from for-in loops
Object.defineProperty(Array.prototype, "equals", {enumerable: false});

// The problem solution code is only the class TrieNode and the contacts function below. 
class TrieNode {
    constructor(){
        this.children = {};
        this.isEndOfWord = false; 
        this.wordCount = 0;
    }

    insert (word) {
        let currentNode = this;
        
        for (let l of word) {
            if (!currentNode.children[l]) {
                currentNode.children[l] = new TrieNode();
            }
            currentNode = currentNode.children[l];
            currentNode.wordCount += 1;
        }
        currentNode.isEndOfWord = true;
    }

    search(word) {
        let currentNode = this;

        for (let l of word) {
            currentNode = currentNode.children[l];
            if (!currentNode) {
                break;
            }
        }
        if (!currentNode) {
            return 0;
        }
        return currentNode.wordCount;
    }
}

/*
 * Complete the 'contacts' function below.
 *
 * The function is expected to return an INTEGER_ARRAY.
 * The function accepts 2D_STRING_ARRAY queries as parameter.
 * 
 * @param {string[][]} queries 
 */
function contacts(queries) {
    let root = new TrieNode();
    const result = [];
    for (q of queries) {
        if (q[0] === 'add') {
            root.insert(q[1]);
        } else if (q[0] === 'find') {
            const r = root.search(q[1]);
            result.push(r)
        }
    }
    return result;
}


let contactsArr = [
    ['add', 'ed'],
    ['add', 'eddie'],
    ['add', 'edward'],
    ['find', 'ed'],
    ['add', 'edwina'],
    ['find', 'edw'],
    ['find', 'a'],
];

let result = contacts(contactsArr)

if (result.equals([3, 2, 0])) {
    console.log(result, "Success!");
} else {
    console.log(result, "Fail!")
}
